using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
    public class MemberList
    {
        private Model.DAL.Registry _registry = new Model.DAL.Registry();
        private List<Member> _members;
        private string _registryPath = "Registry/MemberRegistry.json";
        public IReadOnlyList<Member> All
        {
            get => _members;
        }

        public MemberList()
        {
            _members = GetMemberList();
        }

        private List<Member> GetMemberList()
        {
            return _registry.ReadListFromRegistry<Member>(_registryPath);
        }

        public void UpdateMemberList()
        {
            _registry.WriteListToRegistry<Member>(_members, _registryPath);
        }

        public void Add(Member member)
        {
            _members.Add(member);
            UpdateMemberList();
        }

        public void Delete(Member member)
        {
            _members.Remove(member);
            UpdateMemberList();
        }
    }
}